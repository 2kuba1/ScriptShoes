import Button from '../../ui/button';
import ReviewsStats from './reviewsStats';
import Stars from '../stars';

interface Props {
  shoeId: number;
  numberOfReviews: number;
  averageRating: number;
}

const Reviews = ({ averageRating, numberOfReviews, shoeId }: Props) => {
  return (
    <div className='w-full rounded-xl border-orange border-2 py-3 px-6 flex flex-col gap-4'>
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
      <ReviewsStats shoeId={shoeId} numberOfReviews={numberOfReviews} />
      <Button className='bg-orange w-full h-12 rounded-xl font-semibold text-2xl'>
        Show reviews
      </Button>
    </div>
  );
};

export default Reviews;
