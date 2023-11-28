export default function LoginPage() {
  return (
    <main className='flex justify-center items-center h-without-nav-and-footer gap-9 flex-col'>
      <h1 className='text-4xl font-semibold'>Login</h1>
      <form className='flex flex-col gap-3 w-2/3'>
        <label className='text-2xl' htmlFor='email'>
          Email
        </label>
        <input
          className='h-16 rounded-xl border-2 border-black px-4 text-2xl'
          type='email'
          name='email'
          id='email'
        />

        <label className='text-2xl' htmlFor='password'>
          Password
        </label>
        <input
          className='h-16 rounded-xl border-2 border-black px-4 text-2xl'
          type='password'
          name='password'
          id='password'
        />

        <button
          className='h-16 bg-orange rounded-xl flex items-center justify-center font-semibold'
          type='submit'
        >
          <p className='text-black text-3xl'>Login</p>
        </button>
      </form>
    </main>
  );
}
