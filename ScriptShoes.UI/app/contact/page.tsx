import Link from 'next/link';

export default function ContactPage() {
  return (
    <main className='flex justify-center items-center h-without-nav-and-footer gap-6 flex-col'>
      <h1 className='text-4xl font-semibold'>Contact</h1>
      <a
        className='w-2/3 h-16 bg-orange rounded-xl flex items-center justify-center'
        href='https://github.com/2kuba1/ScriptShoes'
      >
        <p className='text-black text-3xl'>Github repo</p>
      </a>
      <a
        className='w-2/3 h-16 bg-yellow rounded-xl flex items-center justify-center'
        href='mailto:2kubaa1@gmail.com'
      >
        <p className='text-black text-3xl'>Email</p>
      </a>
      <Link
        href='/'
        className='w-2/3 h-16 bg-yellow rounded-xl flex items-center justify-center'
      >
        <p className='text-black text-3xl'>Go to Home</p>
      </Link>
    </main>
  );
}
