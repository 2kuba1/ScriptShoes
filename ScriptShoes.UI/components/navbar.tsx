'use client';

import Image from 'next/image';
import SearchBar from './searchBar';
import useNavbarStore from '@/stores/navbarStore';

const Navbar = () => {
  const { isOpened, setIsOpened } = useNavbarStore();

  return (
    <nav className='h-16 w-full flex items-center bg-yellow px-2 justify-between'>
      {isOpened ? (
        <SearchBar />
      ) : (
        <>
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
        </>
      )}
    </nav>
  );
};

export default Navbar;
