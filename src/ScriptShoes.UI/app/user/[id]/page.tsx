import RequireAuth from '@/utils/requireAuth';
import Image from 'next/image';
import Link from 'next/link';

export default async function UserPage({ params }: { params: { id: string } }) {
  const user = await RequireAuth(params.id);

  return (
    <div className='py-5 px-5 max-w-screen min-h-without-nav-and-footer flex-col gap-6 z-10 flex items-center'>
      <div className='w-full flex justify-center items-center flex-col gap-3'>
        <h1 className='font-bold text-3xl'>Preview</h1>
        <div className='w-48 h-48 bg-dark-blue rounded-full p-1'>
          <Image
            src={user.ProfilePicture}
            alt={user.Username}
            height={500}
            width={500}
            className='rounded-full h-full w-full'
          />
        </div>
        <div className='w-full flex justify-center items-center'>
          <input
            type='text'
            className='w-4/6 rounded-md border-2 border-orange font-semibold p-2 placeholder:text-black text-black text-center'
            placeholder='Username'
            defaultValue={user.Username}
            disabled
          />
          <img src='/svgs/edit.svg' alt='edit' className='w-6 h-6 ml-2' />
        </div>
        <div className='w-full flex justify-center items-center'>
          <input
            type='text'
            className='w-4/6 rounded-md border-2 border-orange font-semibold p-2 placeholder:text-black text-black text-center'
            placeholder='Email'
            defaultValue={user.Email}
            disabled
          />
          <img src='/svgs/edit.svg' alt='edit' className='w-6 h-6 ml-2' />
        </div>
      </div>
      <div className='w-full flex items-center flex-col gap-3'>
        <h1 className='font-bold text-3xl'>Orders</h1>
        <p>no current orders</p>
        <Link
          href='/'
          className='rounded-xl bg-orange text-2xl p-2 font-semibold'
        >
          shop now
        </Link>
      </div>
      <div className='w-full flex flex-col justify-center items-center gap-3'>
        <button className='rounded-xl bg-orange text-2xl p-2 font-semibold w-3/4'>
          reset password
        </button>
        <button className='rounded-xl bg-orange text-2xl p-2 font-semibold w-3/4'>
          delete account
        </button>
        <button className='rounded-xl bg-orange text-2xl p-2 font-semibold w-3/4'>
          logout
        </button>
      </div>
    </div>
  );
}
