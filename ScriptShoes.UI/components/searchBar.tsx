'use client';

import useNavbarStore from '@/stores/navbarStore';
import Image from 'next/image';
import { motion } from 'framer-motion';

const SearchBar = () => {
  const { isOpened, setIsOpened } = useNavbarStore();

  const closeSearchBar = (e: React.KeyboardEvent<HTMLDivElement>) => {
    if (e.keyCode === 27) setIsOpened(!isOpened);
  };

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 1 }}
      onKeyUp={e => closeSearchBar(e)}
      className='h-12 w-full flex items-center justify-center bg-orange px-4 rounded-md'
    >
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
    </motion.div>
  );
};

export default SearchBar;
