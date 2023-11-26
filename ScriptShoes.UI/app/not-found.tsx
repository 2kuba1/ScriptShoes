import Image from 'next/image';
import Link from 'next/link';

export default function NotFound() {
  return (
    <div className='w-screen h-without-nav-and-footer flex flex-col gap-3 items-center justify-center'>
      <Image src='/notfound.png' width={208} height={200} alt='Not found' />
      <p className='text-2xl text-gray'>Page not found</p>
      <Link
        href='/'
        className='bg-orange items-center flex justify-center rounded-xl font-semibold h-8 w-52'
      >
        Go back to home page
      </Link>
    </div>
  );
}
