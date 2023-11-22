'use client';

import useAddReviewCardStore from '@/stores/addReviewCardStore';
import NewReviewStars from './newReviewStars';

const AddReviewCard = () => {
  const { isOpened } = useAddReviewCardStore();

  return (
    <>
      {isOpened && (
        <div className='flex flex-col bg-dark-blue w-full rounded-xl gap-3 py-3 px-9'>
          <p className='text-white font-bold text-3xl text-center'>
            New review
          </p>
          <NewReviewStars />
          <input
            type='text'
            className='rounded-xl bg-dark-blue text-white border-orange border-2 p-2'
            placeholder='Title'
          />
          <textarea
            className='rounded-xl bg-dark-blue text-white border-orange border-2 p-2 resize-none'
            placeholder='Review'
          />
          <button className='bg-orange rounded-xl text-black font-semibold text-xl py-2 px-4'>
            Submit
          </button>
        </div>
      )}
    </>
  );
};

export default AddReviewCard;
