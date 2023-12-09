'use client';

import { Login } from '@/utils/tokens';
import { FormEvent, useEffect, useState } from 'react';
import { useCookies } from 'react-cookie';

export default function LoginPage() {
  const [email, setEmail] = useState<string | null>(null);
  const [password, setPassword] = useState<string | null>(null);

  const [error, setError] = useState<string | null>(null);
  const [success, setSuccess] = useState<string | null>(null);

  const [cookies, setCookies] = useCookies(['accessToken', 'refreshToken']);

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    setError(null);
    setSuccess(null);

    if (email === null || password === null) {
      setError(
        email === null && password === null
          ? 'Email and password are required'
          : email === null
          ? 'Email is required'
          : 'Password is required'
      );
      return;
    }

    const token = await Login(email, password);

    console.log(token);

    if (token === null) {
      setError('Invalid email or password');
      return;
    }

    setCookies('accessToken', token.accessToken, {
      path: '/',
      maxAge:
        (new Date(token.accessTokenExpirationTime).getTime() - Date.now()) /
        1000,
    });

    setCookies('refreshToken', encodeURIComponent(token.refreshToken), {
      path: '/',
      maxAge:
        (new Date(token.refreshTokenExpirationTime).getTime() - Date.now()) /
        10000,
    });

    setSuccess('Login successful');
  };

  return (
    <main className='flex justify-center items-center h-without-nav-and-footer gap-9 flex-col'>
      <h1 className='text-4xl font-semibold'>Login</h1>
      <form
        className='flex flex-col gap-3 w-2/3'
        onSubmit={e => handleSubmit(e)}
      >
        <label className='text-2xl' htmlFor='email'>
          Email
        </label>
        <input
          className='h-16 rounded-xl border-2 border-black px-4 text-2xl'
          type='email'
          name='email'
          id='email'
          onChange={e => setEmail(e.target.value)}
        />

        <label className='text-2xl' htmlFor='password'>
          Password
        </label>
        <input
          className='h-16 rounded-xl border-2 border-black px-4 text-2xl'
          type='password'
          name='password'
          id='password'
          onChange={e => setPassword(e.target.value)}
        />

        <button
          className='h-16 bg-orange rounded-xl flex items-center justify-center font-semibold'
          type='submit'
        >
          <p className='text-black text-3xl'>Login</p>
        </button>
        {error && (
          <p className='font-bold text-xl text-center text-red-600'>{error}</p>
        )}
        {success && (
          <p className='font-bold text-xl text-green-600 text-center'>
            {success}
          </p>
        )}
      </form>
    </main>
  );
}
