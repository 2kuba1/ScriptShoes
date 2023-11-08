'use client';

import useNavbarStore from '@/stores/navbarStore';
import Image from 'next/image';
import { motion } from 'framer-motion';
import { useEffect } from 'react';

const SearchBar = () => {
  const { isOpened, setIsOpened, setSearchPhrase } = useNavbarStore();

  useEffect(() => {
    document.addEventListener('keyup', e => listenForEscapePress(e), true);
  });

  function listenForEscapePress(e: KeyboardEvent) {
    if (e.key !== 'Escape') return;
    setIsOpened(!isOpened);
  }

  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 1 }}
      className='h-12 w-full flex items-center justify-center bg-orange px-4 rounded-md'
    >
      <input
        type='text'
        placeholder='Search'
        className='h-full bg-orange text-black placeholder:text-black text-xl font-semibold w-full outline-none placeholder:opacity-60'
        onChange={e => setSearchPhrase(e.target.value)}
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
