import { getFullStars, getStars } from '@/utils/stars';

interface Props {
  averageRating: number;
}

const Stars = ({ averageRating }: Props) => {
  return (
    <div className='flex items-center gap-1'>
      <div className='flex items-center'>
        {getFullStars(Math.round(averageRating), '#003049', '16', '16').map(
          (star, index) => (
            <div key={index}>{star}</div>
          )
        )}
        {getStars(5 - Math.round(averageRating), '#003049', '16', '16').map(
          (star, index) => (
            <div key={index}>{star}</div>
          )
        )}
      </div>
    </div>
  );
};

export default Stars;
