interface Props {
  currentPrice: number;
  priceBeforeDiscount: number | null;
}

const Price = ({ currentPrice, priceBeforeDiscount }: Props) => {
  return (
    <div className='flex flex-col gap-2 relative right-3'>
      <div className='text-2xl font-bold text-red-800'>
        {currentPrice.toLocaleString('en-US', {
          style: 'currency',
          currency: 'USD',
        })}
      </div>
      {priceBeforeDiscount && (
        <div className='text-xl line-through'>
          {priceBeforeDiscount.toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
          })}
        </div>
      )}
    </div>
  );
};

export default Price;
