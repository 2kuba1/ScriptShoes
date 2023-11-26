import { getFullStars, getStars } from '@/utils/stars';
import Image from 'next/image';

interface Props {
  id: number;
  shoeName: string;
  shoeType: string;
  brand: string;
  currentPrice: number;
  priceBeforeDiscount: number | null;
  averageRating: number;
  numberOfReviews: number;
  thumbnailImage: string;
}

const ShoeCard = (props: Props) => {
  return (
    <div className='w-full h-48 bg-dark-blue p-2 rounded-xl relative'>
      <Image
        src={props.thumbnailImage}
        alt='Shoe'
        className='max-h-44 w-screen rounded-xl'
        width={200}
        height={200}
      />
      <div className='absolute bottom-1 left-4 h-1/4 flex flex-col'>
        <div className='flex w-full items-center'>
          {getFullStars(
            Math.round(props.averageRating),
            '#F77F00',
            '16',
            '16'
          ).map((star, index) => (
            <div key={index}>{star}</div>
          ))}
          {getStars(
            5 - Math.round(props.averageRating),
            '#F77F00',
            '16',
            '16'
          ).map((star, index) => (
            <div key={index}>{star}</div>
          ))}
          <p className='text-orange font-semibold text-sm relative top-1px ml-1'>
            {props.numberOfReviews}
          </p>
        </div>
        <div className='flex items-center gap-2'>
          <div className='text-base font-bold text-red-800'>
            {props.currentPrice.toLocaleString('en-US', {
              style: 'currency',
              currency: 'USD',
            })}
          </div>
          {props.priceBeforeDiscount && (
            <div className='text-base line-through'>
              {props.priceBeforeDiscount.toLocaleString('en-US', {
                style: 'currency',
                currency: 'USD',
              })}
            </div>
          )}
          <p className='text-black font-bold text-sm'>
            {props.brand} - {props.shoeName}
          </p>
        </div>
      </div>
    </div>
  );
};

export default ShoeCard;
