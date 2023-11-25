import Button from '@/components/ui/button';
import ImageSlider from '@/components/shoe/imageSlider';
import Price from '@/components/shoe/price';
import Reviews from '@/components/shoe/reviews/reviews';
import SizeSelector from '@/components/shoe/sizeSelector';
import Stars from '@/components/shoe/stars';
import AddReviewCard from '@/components/shoe/reviews/addReviewCard';
import AddReviewsButton from '@/components/shoe/reviews/addReviewButton';
import ShowReviews from '@/components/shoe/reviews/showReviews';
import axios, { AxiosError } from 'axios';

interface Shoe {
  id: number;
  shoeName: string;
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
  let fetchData = {} as Shoe | AxiosError;

  try {
    const { data }: { data: Shoe } = await axios.get(
      `${process.env.NEXT_PUBLIC_API_URL}/api/shoe/getShoeContent/${params.id}`
    );
    fetchData = data;
  } catch (err) {
    if (err instanceof AxiosError) fetchData = err;
  }

  if (fetchData instanceof AxiosError) return <div>404</div>;

  const images = [
    fetchData.thumbnailImage,
    typeof fetchData.images === 'string' ? fetchData.images : '',
  ];

  return (
    <div className='py-5 px-5 max-w-screen h-without-navbar min-h-without-nav flex flex-col gap-3 z-10'>
      <ImageSlider images={images} />
      <div className=' flex items-center justify-between px-3'>
        <div className='flex flex-col gap-1'>
          <div className='text-2xl'>{fetchData.brand}</div>
          <div className='text-4xl font-bold'>{fetchData.shoeName}</div>
          <div className='flex gap-1 items-center'>
            <Stars averageRating={fetchData.averageRating} />
            <p className='text-sm relative top-1px text-dark-blue font-semibold'>
              {fetchData.numberOfReviews}
            </p>
          </div>
        </div>
        <Price
          currentPrice={fetchData.currentPrice}
          priceBeforeDiscount={fetchData.priceBeforeDiscount}
        />
      </div>
      <SizeSelector shoeSizes={fetchData.shoeSizes} />
      <div className='flex flex-col'>
        <p className='relative left-3'>Available: {fetchData.quantity}</p>
        <div className='flex h-12 w-full justify-between gap-3 font-semibold'>
          <Button className={'rounded-xl bg-orange text-xl w-1/2'}>
            Add to cart
          </Button>
          <Button className={'rounded-xl bg-orange text-xl w-1/2'}>
            Buy now
          </Button>
        </div>
      </div>
      <Reviews
        averageRating={fetchData.averageRating}
        numberOfReviews={fetchData.numberOfReviews}
        shoeId={fetchData.id}
      />
      <AddReviewsButton />
      <AddReviewCard />
      <ShowReviews shoeId={fetchData.id} />
    </div>
  );
}
