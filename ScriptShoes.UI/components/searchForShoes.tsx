'use client';

import Image from 'next/image';
import { useEffect, useState } from 'react';

interface Props {
  searchPhrase: string;
  pageSize: number;
  pageNumber: number;
}

interface Shoe {
  id: number;
  shoeName: string;
  currentPrice: number;
  brand: string;
  priceBeforeDiscount: number;
  thumbnailImage: string;
}

interface SearchResult {
  item: Shoe[];
  totalPages: number;
  itemsFrom: number;
  itemsTo: number;
  totalItemsCount: number;
}

const SearchForShoes = ({ searchPhrase, pageNumber, pageSize }: Props) => {
  const [data, setData] = useState<SearchResult>();

  useEffect(() => {
    const getShoes = async () => {
      const response = await fetch(
        `http://localhost:5013/api/shoe/getShoes/${searchPhrase}?pageNumber=${pageNumber}&pageSize=${pageSize}`,
        {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json',
          },
          cache: 'force-cache',
        }
      );

      setData(await response.json());
    };
    getShoes();
  }, [pageNumber, pageSize, searchPhrase]);

  console.log(data);

  return (
    <>
      {data &&
        data.item.map(shoe => (
          <div
            key={shoe.id}
            className='flex items-center justify-between border-b-2 border-b-gray bg-white w-full h-12 max-w-full p-12 hover:scale-110 cursor-pointer duration-200 dark:bg-gray dark:text-white'
          >
            <h1 className='font-bold text-xl'>{shoe.shoeName}</h1>
            <Image
              src={shoe.thumbnailImage}
              alt={shoe.shoeName}
              width={64}
              height={64}
            />
          </div>
        ))}
    </>
  );
};

export default SearchForShoes;
