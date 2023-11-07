'use client';

import Image from 'next/image';
import SearchBar from './searchBar';
import useNavbarStore from '@/stores/navbarStore';
import { AnimatePresence, motion } from 'framer-motion';

const Navbar = () => {
  const { isOpened, setIsOpened } = useNavbarStore();

  return (
    <AnimatePresence>
      <nav className='h-16 w-full flex items-center bg-yellow px-2'>
        {isOpened ? (
          <SearchBar />
        ) : (
          <motion.div
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            exit={{ opacity: 1 }}
            className='flex items-center justify-between w-full'
          >
            <Image
              src='svgs/logo.svg'
              className='cursor-pointer'
              alt='ScriptShoes Logo'
              width={80}
              height={80}
            />
            <div className='flex gap-3'>
              <Image
                src='svgs/search.svg'
                className='cursor-pointer'
                alt='Search'
                width={28}
                height={28}
                onClick={() => setIsOpened(!isOpened)}
              />
              <Image
                src='svgs/burger.svg'
                className='cursor-pointer'
                alt='Burger'
                width={32}
                height={32}
              />
            </div>
          </motion.div>
        )}
      </nav>
    </AnimatePresence>
  );
};

export default Navbar;
