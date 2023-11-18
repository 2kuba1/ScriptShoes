import Stars from './stars';

interface Props {
  numberOfReviews: number;
  averageRating: number;
}

const Reviews = ({ averageRating, numberOfReviews }: Props) => {
  return (
    <div className='w-full h-72 rounded-xl border-orange border-2 py-3 px-6 flex flex-col'>
      <div className='flex w-ful justify-between items-center'>
        <div className='flex flex-col'>
          <p className='font-bold text-3xl'>Reviews:</p>
          <div className='flex items-center gap-1'>
            <p className='text-xl text-black font-semibold relative top-1px'>
              {numberOfReviews}
            </p>
            <Stars averageRating={averageRating} />
          </div>
        </div>
        <p className='font-bold text-3xl'>
          {Math.round((averageRating * 10) / 10).toFixed(1)}/5
        </p>
      </div>
    </div>
  );
};

export default Reviews;
