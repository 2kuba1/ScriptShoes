'use client';

import useNavbarStore from '@/stores/navbarStore';
import Image from 'next/image';
import Link from 'next/link';
import { useQuery } from '@tanstack/react-query';
import axios from 'axios';

interface Props {
  searchPhrase: string;
  pageSize: number;
  pageNumber: number;
}

interface SearchShoe {
  id: number;
  shoeName: string;
  currentPrice: number;
  brand: string;
  priceBeforeDiscount: number;
  thumbnailImage: string;
}

interface SearchResult {
  item: SearchShoe[];
  totalPages: number;
  itemsFrom: number;
  itemsTo: number;
  totalItemsCount: number;
}

const SearchForShoes = ({ searchPhrase, pageNumber, pageSize }: Props) => {
  const { setIsOpened } = useNavbarStore();

  const { data } = useQuery({
    queryKey: ['searchForShoes', searchPhrase, pageNumber, pageSize],
    queryFn: async () => {
      const { data } = await axios.get(
        `${process.env.NEXT_PUBLIC_API_URL}/api/shoe/getShoes/${searchPhrase}?pageNumber=${pageNumber}&pageSize=${pageSize}`
      );

      return data as SearchResult;
    },
  });

  return (
    <>
      {data &&
        data.item.map(shoe => (
          <Link
            href={`/shoe/${shoe.id}`}
            key={shoe.id}
            onClick={() => {
              setIsOpened(false);
            }}
            className='flex items-center justify-between border-b-2 border-b-gray bg-white w-screen h-12 max-w-full p-12 hover:scale-110 cursor-pointer duration-200 dark:bg-gray dark:text-white z-50'
          >
            <h1 className='font-bold text-xl'>{shoe.shoeName}</h1>
            <Image
              src={shoe.thumbnailImage}
              alt={shoe.shoeName}
              width={64}
              height={64}
            />
          </Link>
        ))}
    </>
  );
};

export default SearchForShoes;
