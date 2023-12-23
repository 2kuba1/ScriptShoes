interface Props {
  error: string;
}

const ErrorCard = ({ error }: Props) => {
  return (
    <>
      <p className='font-bold text-red-600 text-xl text-center'>{error}</p>
    </>
  );
};

export default ErrorCard;
