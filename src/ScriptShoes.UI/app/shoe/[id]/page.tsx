import Button from '@/components/ui/button';
const ImageSlider = dynamic(() => import('@/components/shoe/imageSlider'));
import Price from '@/components/shoe/price';
const Reviews = dynamic(() => import('@/components/shoe/reviews/reviews'));
const SizeSelector = dynamic(() => import('@/components/shoe/sizeSelector'));
const Stars = dynamic(() => import('@/components/shoe/stars'));
const AddReviewCard = dynamic(
  () => import('@/components/shoe/reviews/addReviewCard')
);
const AddReviewsButton = dynamic(
  () => import('@/components/shoe/reviews/addReviewButton')
);
const ShowReviews = dynamic(
  () => import('@/components/shoe/reviews/showReviews')
);
const YouMayAlsoLike = dynamic(
  () => import('@/components/shoe/youMayAlsoLike')
);
import fetchAsync, { Method } from '@/utils/fetchAsync';
import dynamic from 'next/dynamic';

export interface Shoe {
  id: number;
  shoeName: string;
  shoeType: string;
  brand: string;
  shoeSizes: number[];
  currentPrice: number;
  priceBeforeDiscount: number | null;
  averageRating: number;
  numberOfReviews: number;
  quantity: number;
  thumbnailImage: string;
  images: string[];
}

export default async function ShoePage({ params }: { params: { id: number } }) {
  const { data, error } = await fetchAsync<Shoe>(
    `${process.env.NEXT_PUBLIC_API_URL}/api/shoe/getShoeContent/${params.id}`,
    Method.GET
  );

  if (error)
    return (
      <div className='flex w-full h-without-nav-and-footer items-center justify-center'>
        <p className='font-bold text-xl text-red-600 text-center'>
          {error.response?.status === 429
            ? 'Too many requests, try again later'
            : error.response?.status === 404
            ? 'Not found'
            : 'Something went wrong'}
        </p>
      </div>
    );

  const images = [
    data.thumbnailImage,
    typeof data.images === 'string' ? data.images : '',
  ];

  return (
    <div className='py-5 px-5 max-w-screen h-without-navbar min-h-without-nav flex flex-col gap-3 z-10'>
      <ImageSlider images={images} />
      <div className=' flex items-center justify-between px-3'>
        <div className='flex flex-col gap-1'>
          <div className='text-2xl'>{data.brand}</div>
          <div className='text-4xl font-bold'>{data.shoeName}</div>
          <div className='flex gap-1 items-center'>
            <Stars averageRating={data.averageRating} />
            <p className='text-sm relative top-1px text-dark-blue font-semibold'>
              {data.numberOfReviews}
            </p>
          </div>
        </div>
        <Price
          currentPrice={data.currentPrice}
          priceBeforeDiscount={data.priceBeforeDiscount}
        />
      </div>
      <SizeSelector shoeSizes={data.shoeSizes} />
      <div className='flex flex-col'>
        <p className='relative left-3'>Available: {data.quantity}</p>
        <div className='flex h-12 w-full justify-between gap-3 font-semibold'>
          <Button
            className={'rounded-xl bg-orange text-xl w-1/2'}
            name='add to cart'
          >
            Add to cart
          </Button>
          <Button
            className={'rounded-xl bg-orange text-xl w-1/2'}
            name='buy now'
          >
            Buy now
          </Button>
        </div>
      </div>
      <Reviews
        averageRating={data.averageRating}
        numberOfReviews={data.numberOfReviews}
        shoeId={data.id}
      />
      <AddReviewsButton />
      <AddReviewCard />
      <ShowReviews shoeId={data.id} />
      <YouMayAlsoLike {...data} />
    </div>
  );
}
