'use client';

import useShoewReviewsStore from '@/stores/showReviewsStore';

const ShowReviewsButton = () => {
  const { isOpened, setIsOpened } = useShoewReviewsStore();

  return (
    <button
      className='bg-orange w-full h-12 rounded-xl font-semibold text-2xl'
      onClick={() => setIsOpened(!isOpened)}
    >
      {isOpened ? 'Hide reviews' : 'Show reviews'}
    </button>
  );
};

export default ShowReviewsButton;
