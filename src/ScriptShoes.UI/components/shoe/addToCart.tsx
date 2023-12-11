'use client';

import fetchAsync, { Method } from '@/utils/fetchAsync';
import { useCookies } from 'react-cookie';
import { useState } from 'react';
import { refreshAccess } from '@/utils/tokens';

interface Props {
  shoeId: number;
  itemsCount: number;
}

const AddToCart = ({ shoeId, itemsCount }: Props) => {
  const [cookies, setCookies, removeCookie] = useCookies([
    'access_token',
    'refresh_token',
  ]);

  const [error, setError] = useState<number | null>(null);
  const [success, setSuccess] = useState(false);
  const [isPending, setIsPending] = useState(false);

  const addToCart = async () => {
    setIsPending(true);
    setSuccess(false);
    const { error, refetch } = await fetchAsync(
      `${process.env.NEXT_PUBLIC_API_URL}/api/cart/add/shoe/${shoeId}/count/${itemsCount}`,
      Method.POST,
      {},
      {
        Authorization: `Bearer ${cookies.access_token}`,
      }
    );

    if (error) {
      const newToken = await refreshAccess(401, cookies.refresh_token);

      if (!newToken) {
        setIsPending(false);
        setError(401);
        return;
      }

      removeCookie('access_token', { path: '/' });

      setCookies('access_token', newToken?.token, {
        path: '/',
        maxAge: (new Date(newToken!.expires).getTime() - Date.now()) / 1000,
      });

      const { refetchError } = await refetch({
        Authorization: `Bearer ${newToken?.token}`,
      });

      if (refetchError) {
        setError(refetchError.response!.status);
        setIsPending(false);
        return;
      }
    }
    setIsPending(false);
    setSuccess(true);
  };

  return (
    <>
      <button
        className={`rounded-xl ${
          !error && !success
            ? 'bg-orange'
            : !error
            ? 'bg-green-600'
            : 'bg-red-600'
        } text-xl w-1/2 transition duration-300 ease-in-out hover:bg-opacity-80`}
        name='add to cart'
        onClick={addToCart}
      >
        {isPending
          ? 'Adding...'
          : error
          ? 'Error'
          : success
          ? 'Added'
          : 'Add to cart'}
      </button>
    </>
  );
};

export default AddToCart;
