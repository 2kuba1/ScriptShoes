'use client';

import useAddReviewCardStore from '@/stores/addReviewCardStore';
import NewReviewStars from './newReviewStars';
import { AnimatePresence, motion } from 'framer-motion';
import { type FormEvent, useState } from 'react';
import { useCookies } from 'react-cookie';
import { refreshAccess } from '@/utils/tokens';
import fetchAsync, { Method } from '@/utils/fetchAsync';

interface Props {
  shoeId: number;
}

const AddReviewCard = ({ shoeId }: Props) => {
  const { isOpened } = useAddReviewCardStore();

  const [title, setTitle] = useState<string | null>(null);
  const [description, setDescirption] = useState<string | null>(null);
  const [refetched, setRefetched] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const [cookies, setCookies, removeCookie] = useCookies([
    'access_token',
    'refresh_token',
  ]);

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    if (title === null || description === null) {
      return;
    }

    const { error, refetch } = await fetchAsync(
      `${process.env.NEXT_PUBLIC_API_URL}/api/review/create`,
      Method.POST,
      {
        shoeId: shoeId,
        title: title,
        reviewDescription: description,
        shoeRate: 3,
      },
      {
        Authorization: `Bearer ${cookies.access_token}`,
      }
    );

    if (error && !refetched) {
      setRefetched(true);

      const newToken = await refreshAccess(401, cookies.refresh_token);

      removeCookie('access_token', { path: '/' });

      setCookies('access_token', newToken?.token, {
        path: '/',
        maxAge: (new Date(newToken!.expires).getTime() - Date.now()) / 1000,
      });

      const { refetchError } = await refetch({
        Authorization: `Bearer ${newToken?.token}`,
      });

      if (refetchError) {
        switch (refetchError.response?.status) {
          case 400:
            setError('You have already reviewed this shoe');
            break;
          case 401:
            setError('You are not authorized to do this');
            break;
          case 429:
            setError('Too many requests');
            break;
          case 500:
            setError('Internal server error');
            break;
          default:
            setError('Unknown error');
            break;
        }
      }

      return;
    }
  };

  return (
    <AnimatePresence>
      {isOpened && (
        <motion.form
          className='flex flex-col bg-dark-blue w-full rounded-xl gap-3 py-3 px-9'
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          exit={{ opacity: 0 }}
          onSubmit={e => handleSubmit(e)}
        >
          <p className='text-white font-bold text-3xl text-center'>
            New review
          </p>
          <NewReviewStars />
          <input
            type='text'
            className='rounded-xl bg-dark-blue text-white border-orange border-2 p-2'
            placeholder='Title'
            onChange={e => setTitle(e.target.value)}
          />
          <textarea
            className='rounded-xl bg-dark-blue text-white border-orange border-2 p-2 resize-none'
            placeholder='Review'
            onChange={e => setDescirption(e.target.value)}
          />
          <button className='bg-orange rounded-xl text-black font-semibold text-xl py-2 px-4'>
            Submit
          </button>
          {error && (
            <p className='font-bold text-xl text-center text-red-600'>
              {error}
            </p>
          )}
        </motion.form>
      )}
    </AnimatePresence>
  );
};

export default AddReviewCard;
