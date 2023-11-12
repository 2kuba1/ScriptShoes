import Images from '@/components/shoe/imageSlider';
import Stars from '@/components/shoe/stars';
import { cwd } from 'process';

interface Shoe {
  id: number;
  shoeName: string;
  brand: string;
  shoeSizes: number[];
  currentPrice: number;
  priceBeforeDiscount: number;
  averageRating: number;
  numberOfReviews: number;
  quantity: number;
  thumbnailImage: string;
  images: string[];
}

export default async function ShoePage({ params }: { params: { id: number } }) {
  const response = await fetch(
    `${process.env.NEXT_PUBLIC_API_URL}/api/shoe/getShoeContent/${params.id}`,
    {
      headers: {
        'Content-Type': 'application/json',
      },
      method: 'GET',
      cache: 'no-cache',
    }
  );

  const data = (await response.json()) as Shoe;

  const images = [
    data.thumbnailImage,
    ...data.images.filter(image => image !== data.thumbnailImage),
  ];

  return (
    <div className='py-5 px-5 w-screen h-without-navbar min-h-without-nav flex flex-col gap-3'>
      <Images images={images} />
      <div className='relative left-3'>
        <div className='flex flex-col gap-1 ju'>
          <div className='text-2xl'>{data.brand}</div>
          <div className='text-4xl font-bold'>{data.shoeName}</div>
          <Stars
            averageRating={data.averageRating}
            numberOfReviews={data.numberOfReviews}
          />
        </div>
      </div>
    </div>
  );
}
