import axios, { AxiosError } from 'axios';
import Link from 'next/link';
import { type Shoe } from '@/app/shoe/[id]/page';
import ShoeCard from './shoeCard';

interface Props {
  shoeType: string;
  numberOfReviews: number;
}

const YouMayAlsoLike = async ({ shoeType, numberOfReviews }: Props) => {
  const count = 2;

  let fetchData = {} as Shoe[] | AxiosError;

  try {
    const { data } = await axios.get(
      `${process.env.NEXT_PUBLIC_API_URL}/api/shoe/getShoesByType?shoeType=${shoeType}&count=${count}`
    );

    fetchData = data as Shoe[];
  } catch (err) {
    if (err instanceof AxiosError) fetchData = err;
  }

  if (fetchData instanceof AxiosError)
    return (
      <div className='flex w-full h-12 items-center justify-center'>
        <p className='font-bold text-xl text-black text-center'>
          {fetchData.response?.status === 429
            ? 'Too many requests, try again later'
            : fetchData.response?.status === 404
            ? 'Not found'
            : 'Something went wrong'}
        </p>
      </div>
    );

  return (
    <div className='flex flex-col w-full items-center'>
      <p className='font-bold text-3xl text-center mb-3'>You may also like:</p>
      <div className='flex gap-3'>
        {fetchData.map(shoe => (
          <Link href={`/shoe/${shoe.id}`} key={shoe.id}>
            <ShoeCard {...shoe} numberOfReviews={numberOfReviews} />
          </Link>
        ))}
      </div>
    </div>
  );
};

export default YouMayAlsoLike;
