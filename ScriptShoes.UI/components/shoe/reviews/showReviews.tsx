'use client';

import { useEffect, useRef, useState } from 'react';
import useShoewReviewsStore from '@/stores/showReviewsStore';
import { AnimatePresence, motion } from 'framer-motion';
import { useQuery } from '@tanstack/react-query';
import axios from 'axios';
import { getFullStars, getStars } from '@/utils/stars';

interface Props {
  shoeId: number;
}

interface Reviews {
  item: {
    id: number;
    title: string;
    reviewDescription: string;
    likes: number;
    shoeRate: number;
    username: string;
    created: string;
  }[];
  totalPages: number;
  itemsFrom: number;
  itemsTo: number;
  totalItemsCount: number;
}

const ShowReviews = ({ shoeId }: Props) => {
  const { isOpened } = useShoewReviewsStore();

  const [review, setReview] = useState<Reviews>();
  const [hasMore, setHasMore] = useState(true);
  const [pageNumber, setPageNumber] = useState(1);

  const pageSzie = 5;

  const { data } = useQuery({
    queryKey: ['getReviews', shoeId, pageNumber, pageSzie],
    queryFn: async () => {
      const { data } = await axios.get(
        `${process.env.NEXT_PUBLIC_API_URL}/api/review/getPagedReviews?shoeId=${shoeId}&pageNumber=${pageNumber}&pageSize=${pageSzie}`
      );

      return data as Reviews;
    },
    retry: true,
    retryDelay: 2000,
  });

  const onIntersection = (entries: IntersectionObserverEntry[]) => {
    if (entries[0].isIntersecting && hasMore) {
      getReviews();
    }
  };

  const getReviews = async () => {
    if (!data) return;

    if (data.item.length === 0) {
      setHasMore(false);
      return;
    }

    const newReviews = {
      ...data,
      item: review?.item ? [...review.item, ...data.item] : data.item,
    };

    setReview(newReviews);
    setPageNumber(page => page + 1);
  };

  const elementRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const observer = new IntersectionObserver(onIntersection);

    if (observer && elementRef.current) {
      observer.observe(elementRef.current);
    }

    return () => {
      // eslint-disable-next-line react-hooks/exhaustive-deps
      if (observer && elementRef.current) {
        observer.disconnect();
      }
    };
  });

  return (
    <AnimatePresence>
      {isOpened && (
        <motion.div
          className='bg-dark-blue h-96 w-full rounded-xl flex flex-col overflow-y-scroll py-3 px-6 gap-3'
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          exit={{ opacity: 0 }}
        >
          {review?.item.map(item => (
            <div
              key={item.id}
              className='flex flex-col border-4 rounded-xl border-orange p-3'
            >
              <div className='flex items-center justify-between mb-3'>
                <div className='flex flex-col'>
                  <p className='text-white font-semibold text-3xl'>
                    {item.username}
                  </p>
                  <div className='flex'>
                    {getFullStars(item.shoeRate, 'white', '25', '25').map(
                      star => (
                        <div key={Math.random()}>{star}</div>
                      )
                    )}
                    {getStars(item.shoeRate, 'white', '25', '25').map(star => (
                      <div key={Math.random()}>{star}</div>
                    ))}
                  </div>
                </div>
                <p className='text-2xl font-semibold text-white'>
                  {item.shoeRate}/5
                </p>
              </div>
              <p className='text-2xl text-white font-bold'>{item.title}</p>
              <p className='text-white'>{item.reviewDescription}</p>
              <div className='border-2 border-orange h-1 rounded-xl mb-2'></div>
              <div className='flex items-center gap-2'>
                <svg
                  width='25'
                  height='25'
                  viewBox='0 0 40 37'
                  fill='none'
                  xmlns='http://www.w3.org/2000/svg'
                >
                  <path
                    d='M20 36.9501L17.95 35.1C14.4167 31.8667 11.5 29.075 9.2 26.725C6.9 24.375 5.06667 22.275 3.7 20.425C2.33333 18.575 1.375 16.9 0.825 15.4C0.275 13.9 0 12.3834 0 10.85C0 7.85005 1.00833 5.34171 3.025 3.32505C5.04167 1.30838 7.53333 0.300049 10.5 0.300049C12.4 0.300049 14.1583 0.750049 15.775 1.65005C17.3917 2.55005 18.8 3.85005 20 5.55005C21.4 3.75005 22.8833 2.42505 24.45 1.57505C26.0167 0.725048 27.7 0.300049 29.5 0.300049C32.4667 0.300049 34.9583 1.30838 36.975 3.32505C38.9917 5.34171 40 7.85005 40 10.85C40 12.3834 39.725 13.9 39.175 15.4C38.625 16.9 37.6667 18.575 36.3 20.425C34.9333 22.275 33.1 24.375 30.8 26.725C28.5 29.075 25.5833 31.8667 22.05 35.1L20 36.9501ZM20 33C23.3667 29.9 26.1417 27.2417 28.325 25.025C30.5083 22.8084 32.2417 20.8667 33.525 19.2001C34.8083 17.5334 35.7083 16.05 36.225 14.75C36.7417 13.45 37 12.15 37 10.85C37 8.65005 36.3 6.84172 34.9 5.42505C33.5 4.00838 31.7 3.30005 29.5 3.30005C27.8 3.30005 26.2167 3.82505 24.75 4.87505C23.2833 5.92505 22.1 7.40005 21.2 9.30005H18.75C17.8833 7.43338 16.7167 5.96671 15.25 4.90005C13.7833 3.83338 12.2 3.30005 10.5 3.30005C8.3 3.30005 6.5 4.00838 5.1 5.42505C3.7 6.84172 3 8.65005 3 10.85C3 12.15 3.25833 13.4584 3.775 14.775C4.29167 16.0917 5.19167 17.5917 6.475 19.275C7.75833 20.9584 9.5 22.9 11.7 25.1C13.9 27.3 16.6667 29.9334 20 33Z'
                    fill='red'
                  />
                </svg>

                <p className='text-white text-2xl font-semibold'>
                  {item.likes}
                </p>
              </div>
            </div>
          ))}
          {hasMore && (
            <div ref={elementRef}>
              <p className='text-center text-white font-semibold text-xl'>
                Loading ...
              </p>
            </div>
          )}
        </motion.div>
      )}
    </AnimatePresence>
  );
};

export default ShowReviews;
