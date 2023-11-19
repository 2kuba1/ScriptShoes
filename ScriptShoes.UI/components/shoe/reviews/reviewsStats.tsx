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
  const drawStarts = (numberOfStars: number) => {
    const stars = [];

    for (let i = 0; i < numberOfStars; i++) {
      stars.push(
        <svg
          width='16'
          height='16'
          viewBox='0 0 40 39'
          fill='none'
          xmlns='http://www.w3.org/2000/svg'
        >
          <path
            d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
            fill='#003049'
          />
        </svg>
      );
    }

    return stars;
  };

  const response = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL}/api/review/getShoeRates/${shoeId}`
  );
  const data = (await response.json()) as ReviewStats;

  const fiveStarsPercentage = (data.fiveStarsCount * 100) / numberOfReviews;
  const fourStarsPercentage = (data.fourStarsCount * 100) / numberOfReviews;
  const threeStarsPercentage = (data.threeStarsCount * 100) / numberOfReviews;
  const twoStarsPercentage = (data.twoStarsCount * 100) / numberOfReviews;
  const oneStarsPercentage = (data.oneStarsCount * 100) / numberOfReviews;

  return (
    <div className='flex flex-col w-full'>
      <div className='flex items-center justify-between'>
        <div className='flex gap-1'>
          {drawStarts(5).map((star, index) => (
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
          {drawStarts(4).map((star, index) => (
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
          {drawStarts(3).map((star, index) => (
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
          {drawStarts(2).map((star, index) => (
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
          {drawStarts(1).map((star, index) => (
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
