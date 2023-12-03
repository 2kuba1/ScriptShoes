import { useState } from 'react';

const NewReviewStars = () => {
  const [starsHovered, setStarsHovered] = useState(0);
  const [rating, setRating] = useState(0);

  return (
    <div className='flex items-center justify-between'>
      <p className='text-white text-2xl relative top-3px'>Rating</p>
      <div className='flex'>
        <div
          onMouseEnter={() => rating === 0 && setStarsHovered(1)}
          onMouseLeave={() => rating === 0 && setStarsHovered(0)}
          onClick={() => {
            rating === 1 ? setRating(0) : setRating(1);
            rating === 1 ? setStarsHovered(0) : setStarsHovered(1);
          }}
        >
          {starsHovered >= 1 ? (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          ) : (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          )}
        </div>
        <div
          onMouseEnter={() => rating === 0 && setStarsHovered(2)}
          onMouseLeave={() => rating === 0 && setStarsHovered(0)}
          onClick={() => {
            rating === 2 ? setRating(0) : setRating(2);
            rating === 2 ? setStarsHovered(0) : setStarsHovered(2);
          }}
        >
          {starsHovered >= 2 ? (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          ) : (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          )}
        </div>
        <div
          onMouseEnter={() => rating === 0 && setStarsHovered(3)}
          onMouseLeave={() => rating === 0 && setStarsHovered(0)}
          onClick={() => {
            rating === 3 ? setRating(0) : setRating(3);
            rating === 3 ? setStarsHovered(0) : setStarsHovered(3);
          }}
        >
          {starsHovered >= 3 ? (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          ) : (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          )}
        </div>
        <div
          onMouseEnter={() => rating === 0 && setStarsHovered(4)}
          onMouseLeave={() => rating === 0 && setStarsHovered(0)}
          onClick={() => {
            rating === 4 ? setRating(0) : setRating(4);
            rating === 4 ? setStarsHovered(0) : setStarsHovered(4);
          }}
        >
          {starsHovered >= 4 ? (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          ) : (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          )}
        </div>
        <div
          onMouseEnter={() => rating === 0 && setStarsHovered(5)}
          onMouseLeave={() => rating === 0 && setStarsHovered(0)}
          onClick={() => {
            rating === 5 ? setRating(0) : setRating(5);
            rating === 5 ? setStarsHovered(0) : setStarsHovered(5);
          }}
        >
          {starsHovered >= 5 ? (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          ) : (
            <svg
              width='25'
              height='25'
              viewBox='0 0 40 39'
              fill='none'
              xmlns='http://www.w3.org/2000/svg'
            >
              <path
                d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
                fill='white'
              />
            </svg>
          )}
        </div>
      </div>
    </div>
  );
};

export default NewReviewStars;
