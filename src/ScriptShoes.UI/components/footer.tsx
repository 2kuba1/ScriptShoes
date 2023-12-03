import Image from 'next/image';
import Link from 'next/link';

const Footer = () => {
  return (
    <footer className='mt-auto w-full h-14 bg-yellow flex items-center justify-between p-6'>
      <Link href='/'>
        <Image
          src='/svgs/logo.svg'
          alt='logo'
          width={48}
          height={48}
          className='object-contain scale-125'
        />
      </Link>
      <p className='text-xl text-center'>© 2023</p>
      <div className='flex gap-3 items-center'>
        <div className='flex flex-col text-3xs'>
          <Link href='/about'>Contact</Link>
          <Link href='/about'>About</Link>
          <Link href='/about'>Account</Link>
          <Link href='/about'>Cart</Link>
        </div>
        <a href='https://github.com/2kuba1/ScriptShoes' target='_blank'>
          <Image
            src='/svgs/github.svg'
            alt='logo'
            width={36}
            height={36}
            className='object-contain'
          />
        </a>
      </div>
    </footer>
  );
};

export default Footer;
