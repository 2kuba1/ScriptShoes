'use client';

import { useState } from 'react';

export default function RegisterPage() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [username, setUsername] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [confirmedPassword, setConfirmedPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (password !== confirmedPassword) {
      setError('Passwords do not match');
      return;
    }

    const res = await fetch(
      `${process.env.NEXT_PUBLIC_API_URL}/api/user/register`,
      {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          username: username,
          email: email,
          password: password,
          confirmedPassword: confirmedPassword,
          firstName: firstName,
          lastName: lastName,
        }),
      }
    );

    if (res.status === 204) {
      window.location.href = '/login?registered=true';
    } else {
      setError('Invalid credentials');
    }
  };

  return (
    <main className='flex justify-center items-center h-without-nav-and-footer gap-2 flex-col'>
      <h1 className='text-2xl font-semibold'>Register</h1>
      <form className='flex flex-col gap-2 w-2/3' onSubmit={handleSubmit}>
        <label className='text-xl' htmlFor='email'>
          Email
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='email'
          name='email'
          onChange={e => setEmail(e.target.value)}
        />
        <label className='text-xl' htmlFor='username'>
          Username
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='text'
          name='username'
          onChange={e => setUsername(e.target.value)}
        />
        <label className='text-xl' htmlFor='first-name'>
          First Name
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='text'
          name='first-name'
          onChange={e => setFirstName(e.target.value)}
        />
        <label className='text-xl' htmlFor='last-name'>
          Last Name
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='text'
          name='last-name'
          onChange={e => setLastName(e.target.value)}
        />
        <label className='text-xl' htmlFor='password'>
          Password
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='password'
          name='password'
          onChange={e => setPassword(e.target.value)}
        />
        <label className='text-xl' htmlFor='confirm-password'>
          Confirm Password
        </label>
        <input
          className='h-8 rounded-xl border-2 border-black px-2 text-xl'
          type='password'
          name='confirm-password'
          onChange={e => setConfirmedPassword(e.target.value)}
        />
        <button
          className='h-8 bg-orange rounded-xl flex items-center justify-center font-semibold'
          type='submit'
        >
          <p className='text-black text-2xl'>Login</p>
        </button>
      </form>
      {error && <p className='text-red-600 font-bold text-center'>{error}</p>}
    </main>
  );
}
