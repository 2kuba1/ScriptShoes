'use client';

import { useState } from 'react';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import z, { type ZodType } from 'zod';

type FormData = {
  email: string;
  password: string;
  username: string;
  firstName: string;
  lastName: string;
  confirmedPassword: string;
};

export default function RegisterPage() {
  const [error, setError] = useState('');

  const schema: ZodType<FormData> = z
    .object({
      username: z.string().min(3).max(50),
      firstName: z.string().min(3).max(50),
      lastName: z.string().min(3).max(50),
      email: z.string().email(),
      password: z.string().min(8).max(25),
      confirmedPassword: z.string().min(8).max(25),
    })
    .refine(data => data.password === data.confirmedPassword, {
      message: 'Passwords do not match',
      path: ['confirmedPassword'],
    });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const submitData = async ({
    confirmedPassword,
    email,
    firstName,
    lastName,
    password,
    username,
  }: FormData) => {
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
    <main className='flex justify-center items-center min-h-without-nav-and-footer gap-2 flex-col'>
      <h1 className='text-2xl font-semibold'>Register</h1>
      <form className='flex flex-col w-2/3' onSubmit={handleSubmit(submitData)}>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='email'>
            Email
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='email'
            {...register('email')}
          />
          {errors.email && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.email.message}
            </p>
          )}
        </div>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='username'>
            Username
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='text'
            {...register('username')}
          />
          {errors.username && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.username.message}
            </p>
          )}
        </div>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='firstName'>
            First Name
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='text'
            {...register('firstName')}
          />
          {errors.firstName && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.firstName.message}
            </p>
          )}
        </div>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='lastName'>
            Last Name
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='text'
            {...register('lastName')}
          />
          {errors.lastName && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.lastName.message}
            </p>
          )}
        </div>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='password'>
            Password
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='password'
            {...register('password')}
          />
          {errors.password && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.password.message}
            </p>
          )}
        </div>
        <div className='flex flex-col gap-1'>
          <label className='text-xl' htmlFor='confirmedPassword'>
            Confirm Password
          </label>
          <input
            className='h-8 rounded-xl border-2 border-black px-2 text-xl'
            type='password'
            {...register('confirmedPassword')}
          />
          {errors.confirmedPassword && (
            <p className='text-red-600 font-bold text-center text-xs'>
              {errors.confirmedPassword.message}
            </p>
          )}
        </div>
        <button
          className='h-8 bg-orange rounded-xl mt-3 flex items-center justify-center font-semibold'
          type='submit'
        >
          <p className='text-black text-2xl'>Login</p>
        </button>
      </form>
      {error && <p className='text-red-600 font-bold text-center'>{error}</p>}
    </main>
  );
}
