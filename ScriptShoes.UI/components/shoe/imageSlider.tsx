'use client';

import { useState } from 'react';
import Image from 'next/image';

interface Props {
  images: string[];
}

const ImageSlider = ({ images }: Props) => {
  const [currentImage, setCurrentImage] = useState(0);

  return (
    <div className='w-full bg-dark-blue h-72 flex items-center justify-center rounded-xl relative'>
      <div
        className='ml-2 text-center text-3xl font-bold absolute left-0 cursor-pointer hover:scale-110 duration-200'
        onClick={() =>
          images[currentImage - 1] !== undefined
            ? setCurrentImage(currentImage - 1)
            : null
        }
      >
        <Image
          src='/svgs/pointer-left.svg'
          alt='Arrow Right'
          width={16}
          height={16}
        />
      </div>
      <Image
        src={images[currentImage]}
        alt='Shoe'
        className='max-h-72 w-full rounded-xl p-1'
        width={200}
        height={200}
      />
      <div
        className='mr-2 text-center text-3xl font-bold absolute right-0 cursor-pointer hover:scale-110 duration-200'
        onClick={() =>
          images[currentImage + 1] !== undefined
            ? setCurrentImage(currentImage + 1)
            : null
        }
      >
        <Image
          src='/svgs/pointer-right.svg'
          alt='Arrow Right'
          width={16}
          height={16}
        />
      </div>
    </div>
  );
};

export default ImageSlider;
