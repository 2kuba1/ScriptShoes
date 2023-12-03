import { Skeleton } from '@/components/ui/skeleton';

export default function Loading() {
  return (
    <div className='py-5 px-5 max-w-screen h-without-navbar min-h-without-nav flex flex-col gap-3 z-10'>
      <Skeleton className='h-72 w-full rounded-xl bg-gray' />
      <div className=' flex items-center justify-between px-3'>
        <div className='flex flex-col gap-3'>
          <Skeleton className='h-4 w-32 rounded-xl bg-gray' />
          <Skeleton className='h-8 w-40 rounded-xl bg-gray' />
          <Skeleton className='h-4 w-36 rounded-xl bg-gray' />
        </div>
        <div className='flex flex-col gap-3'>
          <Skeleton className='h-6 w-24 rounded-xl bg-gray' />
          <Skeleton className='h-6 w-24 rounded-xl bg-gray' />
        </div>
      </div>
      <Skeleton className='h-12 w-full rounded-xl bg-gray' />
      <Skeleton className='h-4 w-2/5 rounded-xl bg-gray' />
      <div className='flex justify-between gap-3'>
        <Skeleton className='h-12 w-1/2 rounded-xl bg-gray' />
        <Skeleton className='h-12 w-1/2 rounded-xl bg-gray' />
      </div>
      <Skeleton className='h-72 w-full rounded-xl bg-gray' />
      <div className='flex justify-center w-full'>
        <Skeleton className='h-6 w-3/4 rounded-xl bg-gray' />
      </div>
      <Skeleton className='h-48 w-full rounded-xl bg-gray' />
      <Skeleton className='h-48 w-full rounded-xl bg-gray' />
    </div>
  );
}
