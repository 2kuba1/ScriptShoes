'use client';

import useAddReviewCardStore from '@/stores/addReviewCardStore';

const AddReviewsButton = () => {
  const { isOpened, setIsOpened } = useAddReviewCardStore();

  return (
    <button
      className='bg-orange w-full h-12 rounded-xl font-semibold text-2xl'
      onClick={() => setIsOpened(!isOpened)}
    >
      {isOpened ? 'Close' : 'Add review'}
    </button>
  );
};

export default AddReviewsButton;
