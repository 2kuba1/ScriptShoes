'use client';

import useAddReviewCardStore from '@/stores/addReviewCardStore';
import { useState } from 'react';
import NewReviewStars from './newReviewStars';

const AddReviewCard = () => {
  const { isOpened } = useAddReviewCardStore();

  return (
    <>
      {isOpened && (
        <div className='flex flex-col bg-dark-blue h-72 w-full rounded-xl gap-3 py-3 px-6'>
          <p className='text-white font-bold text-3xl text-center'>
            New review
          </p>
          <NewReviewStars />
        </div>
      )}
    </>
  );
};

export default AddReviewCard;
