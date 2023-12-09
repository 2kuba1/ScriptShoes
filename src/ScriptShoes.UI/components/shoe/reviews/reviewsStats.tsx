import fetchAsync, { Method } from '@/utils/fetchAsync';
import { getFullStars } from '@/utils/stars';
import axios, { AxiosError } from 'axios';

interface Props {
  shoeId: number;
  numberOfReviews: number;
}

interface ReviewStats {
  shoeId: number;
  oneStarsCount: number;
  twoStarsCount: number;
  threeStarsCount: number;
  fourStarsCount: number;
  fiveStarsCount: number;
}

const ReviewsStats = async ({ shoeId, numberOfReviews }: Props) => {
  const { data, error } = await fetchAsync<ReviewStats>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/review/getShoeRates/${shoeId}`,
    Method.GET
  );

  if (error)
    return (
      <div className='flex w-full h-12 items-center justify-center'>
        <p className='font-bold text-xl text-black text-center'>
          {error.response?.status === 429
            ? 'Too many requests, try again later'
            : error.response?.status === 404
            ? 'Not found'
            : 'Something went wrong'}
        </p>
      </div>
    );

  let fiveStarsPercentage;
  let fourStarsPercentage;
  let threeStarsPercentage;
  let twoStarsPercentage;
  let oneStarsPercentage;

  if (numberOfReviews === 0) {
    fiveStarsPercentage = (data.fiveStarsCount * 100) / 1;
    fourStarsPercentage = (data.fourStarsCount * 100) / 1;
    threeStarsPercentage = (data.threeStarsCount * 100) / 1;
    twoStarsPercentage = (data.twoStarsCount * 100) / 1;
    oneStarsPercentage = (data.oneStarsCount * 100) / 1;
  } else {
    fiveStarsPercentage = (data.fiveStarsCount * 100) / numberOfReviews;
    fourStarsPercentage = (data.fourStarsCount * 100) / numberOfReviews;
    threeStarsPercentage = (data.threeStarsCount * 100) / numberOfReviews;
    twoStarsPercentage = (data.twoStarsCount * 100) / numberOfReviews;
    oneStarsPercentage = (data.oneStarsCount * 100) / numberOfReviews;
  }

  return (
    <div className='flex flex-col w-full'>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {getFullStars(5, '#003049', '16', '16').map((star, index) => (
            <div key={index}>{star}</div>
          ))}
        </div>
        <div className='flex w-3/5'>
          <div
            className={`h-1 rounded-r-xl bg-orange`}
            style={{
              width: fiveStarsPercentage.toString() + '%',
            }}
          ></div>
          <div
            className={`h-1 rounded-r-xl bg-yellow`}
            style={{
              width: (100 - fiveStarsPercentage).toString() + '%',
            }}
          ></div>
        </div>
      </div>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {getFullStars(4, '#003049', '16', '16').map((star, index) => (
            <div key={index}>{star}</div>
          ))}
        </div>
        <div className='flex w-3/5'>
          <div
            className={`h-1 rounded-r-xl bg-orange`}
            style={{
              width: fourStarsPercentage.toString() + '%',
            }}
          ></div>
          <div
            className={`h-1 rounded-r-xl bg-yellow`}
            style={{
              width: (100 - fourStarsPercentage).toString() + '%',
            }}
          ></div>
        </div>
      </div>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {getFullStars(3, '#003049', '16', '16').map((star, index) => (
            <div key={index}>{star}</div>
          ))}
        </div>
        <div className='flex w-3/5'>
          <div
            className={`h-1 rounded-r-xl bg-orange`}
            style={{
              width: threeStarsPercentage.toString() + '%',
            }}
          ></div>
          <div
            className={`h-1 rounded-r-xl bg-yellow`}
            style={{
              width: (100 - threeStarsPercentage).toString() + '%',
            }}
          ></div>
        </div>
      </div>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {getFullStars(2, '#003049', '16', '16').map((star, index) => (
            <div key={index}>{star}</div>
          ))}
        </div>
        <div className='flex w-3/5'>
          <div
            className={`h-1 rounded-r-xl bg-orange`}
            style={{
              width: twoStarsPercentage.toString() + '%',
            }}
          ></div>
          <div
            className={`h-1 rounded-r-xl bg-yellow`}
            style={{
              width: (100 - twoStarsPercentage).toString() + '%',
            }}
          ></div>
        </div>
      </div>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {getFullStars(1, '#003049', '16', '16').map((star, index) => (
            <div key={index}>{star}</div>
          ))}
        </div>
        <div className='flex w-3/5'>
          <div
            className={`h-1 rounded-r-xl bg-orange`}
            style={{
              width: oneStarsPercentage.toString() + '%',
            }}
          ></div>
          <div
            className={`h-1 rounded-r-xl bg-yellow`}
            style={{
              width: (100 - oneStarsPercentage).toString() + '%',
            }}
          ></div>
        </div>
      </div>
    </div>
  );
};

export default ReviewsStats;
