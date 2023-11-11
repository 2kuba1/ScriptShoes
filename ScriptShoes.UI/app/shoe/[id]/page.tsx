import Images from '@/components/shoe/imageSlider';

interface Shoe {
  id: number;
  shoeName: string;
  brand: string;
  shoeSizes: number[];
  currentPrice: number;
  priceBeforeDiscount: number;
  averageRating: number;
  numberOfRatings: number;
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
    }
  );

  const data = (await response.json()) as Shoe;

  const images = [
    data.thumbnailImage,
    ...data.images.filter(image => image !== data.thumbnailImage),
  ];

  return (
    <div className='py-5 px-5 w-screen h-without-navbar min-h-without-nav flex flex-col items-center'>
      <Images images={images} />
    </div>
  );
}
