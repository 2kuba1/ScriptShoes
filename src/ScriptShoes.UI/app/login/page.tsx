'use client';

import { Login } from '@/utils/tokens';
import { FormEvent, useEffect, useState } from 'react';
import { useCookies } from 'react-cookie';
import z from 'zod';

export default function LoginPage() {
  const schema = z
    .object({
      firstName: z.string().min(2).max(50),
      lastName: z.string().min(2).max(50),
      email: z.string().email(),
      password: z.string().min(8).max(25),
      confirmPassword: z.string().min(8).max(25),
    })
    .refine(data => data.password === data.confirmPassword, {
      message: 'Passwords do not match',
      path: ['confirmPassword'],
    });

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const [cookies, setCookies] = useCookies(['access_token', 'refresh_token']);

  const [registerSuccess, setRegisterSuccess] = useState(false);

  useEffect(() => {
    if (window.location.href.includes('registered=true')) {
      setRegisterSuccess(true);
    }
  }, []);

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();

    setError('');
    setSuccess('');

    if (!email || !password) {
      setError(
        !email && !password
          ? 'Email and password are required'
          : !email
          ? 'Email is required'
          : 'Password is required'
      );
      return;
    }

    const token = await Login(email, password);

    if (token === null) {
      setError('Invalid email or password');
      return;
    }

    setCookies('access_token', token.accessToken, {
      path: '/',
      maxAge:
        (new Date(token.accessTokenExpirationTime).getTime() - Date.now()) /
        1000,
    });

    setCookies('refresh_token', encodeURIComponent(token.refreshToken), {
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
      {registerSuccess && (
        <p className='text-green-600 font-bold  text-center'>
          Registration successful
        </p>
      )}
    </main>
  );
}
