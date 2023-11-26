export const getFullStars = (
  howManyStars: number,
  color: string,
  height: string,
  width: string
) => {
  const stars = [];

  for (let i = 0; i < howManyStars; i++) {
    stars.push(
      <svg
        key={i}
        width={width}
        height={height}
        viewBox='0 0 40 39'
        fill='none'
        xmlns='http://www.w3.org/2000/svg'
      >
        <path
          d='M7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
          fill={color}
        />
      </svg>
    );
  }

  return stars;
};

export const getStars = (
  howManyStars: number,
  color: string,
  height: string,
  width: string
) => {
  const stars = [];

  for (let i = 0; i < howManyStars; i++) {
    stars.push(
      <svg
        width={width}
        height={height}
        viewBox='0 0 40 39'
        fill='none'
        xmlns='http://www.w3.org/2000/svg'
      >
        <path
          d='M12.15 32.3757L20 27.6757L27.85 32.4257L25.75 23.5257L32.65 17.5257L23.55 16.7257L20 8.32573L16.45 16.6757L7.35 17.4757L14.25 23.4757L12.15 32.3757ZM7.65 38.6257L10.9 24.5757L0 15.1257L14.4 13.8757L20 0.625732L25.6 13.8757L40 15.1257L29.1 24.5757L32.35 38.6257L20 31.1757L7.65 38.6257Z'
          fill={color}
        />
      </svg>
    );
  }

  return stars;
};
