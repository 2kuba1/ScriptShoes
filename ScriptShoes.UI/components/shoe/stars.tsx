interface Props {
  averageRating: number;
  numberOfReviews: number;
}

const Stars = ({ averageRating, numberOfReviews }: Props) => {
  const drawStarts = () => {
    const stars = [];

    for (let i = 0; i < Math.round(averageRating); i++) {
      stars.push(
        <path
          d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
          fill='#003049'
        />
      );
    }

    for (let i = 0; i < 5 - Math.round(averageRating); i++) {
      stars.push(
        <path
          d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
          fill='#003049'
        />
      );
    }

    return stars;
  };

  return (
    <div className='flex items-center gap-1'>
      <div className='flex items-center'>
        {drawStarts().map((star, index) => (
          <div key={index}>
            <svg
              width='40'
              height='39'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
              className='h-4 w-4'
            >
              {star}
            </svg>
          </div>
        ))}
      </div>
      <p className='font-bold text-center text-xs text-dark-blue'>
        {numberOfReviews}
      </p>
    </div>
  );
};

export default Stars;
