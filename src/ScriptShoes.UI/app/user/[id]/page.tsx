import RequireAuth from '@/utils/requireAuth';

export default async function UserPage({ params }: { params: { id: string } }) {
  await RequireAuth(params.id);

  return (
    <div className='py-5 px-5 max-w-screen h-without-navbar min-h-without-nav flex flex-col gap-3 z-10'>
      <h1 className='font-bold'>Preview</h1>
    </div>
  );
}
