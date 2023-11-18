import Button from '@/components/button';
import ImageSlider from '@/components/shoe/imageSlider';
import Price from '@/components/shoe/price';
import SizeSelector from '@/components/shoe/sizeSelector';
import Stars from '@/components/shoe/stars';

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
    <div className='py-5 px-5 w-screen h-without-navbar min-h-without-nav flex flex-col gap-3 z-10'>
      <ImageSlider images={images} />
      <div className=' flex items-center justify-between px-3'>
        <div className='flex flex-col gap-1'>
          <div className='text-2xl'>{data.brand}</div>
          <div className='text-4xl font-bold'>{data.shoeName}</div>
          <Stars
            averageRating={data.averageRating}
            numberOfReviews={data.numberOfReviews}
          />
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
          <Button className={'rounded-xl bg-orange text-xl w-1/2'}>
            Add to cart
          </Button>
          <Button className={'rounded-xl bg-orange text-xl w-1/2'}>
            Buy now
          </Button>
        </div>
      </div>
    </div>
  );
}
