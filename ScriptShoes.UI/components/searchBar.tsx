'use client';

import useNavbarStore from '@/stores/navbarStore';
import Image from 'next/image';

const SearchBar = () => {
  const { isOpened, setIsOpened } = useNavbarStore();

  return (
    <div className='h-12 w-full flex items-center justify-center bg-orange px-4 rounded-md'>
      <input
        type='text'
        placeholder='Search'
        className='h-full bg-orange text-black placeholder:text-black text-xl font-semibold w-full outline-none'
      />
      <Image
        src='/svgs/reject.svg'
        alt='Reject'
        className='cursor-pointer'
        width={24}
        height={24}
        onClick={() => setIsOpened(!isOpened)}
      />
    </div>
  );
};

export default SearchBar;
