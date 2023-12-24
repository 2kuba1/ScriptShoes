'use client';

import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from '../ui/select';

interface Props {
  shoeSizes: number[];
}

const SizeSelector = ({ shoeSizes }: Props) => {
  return (
    <Select>
      <SelectTrigger className='w-full bg-orange font-semibold'>
        <SelectValue placeholder='Select Size' />
      </SelectTrigger>
      <SelectContent className='dark:bg-gray dark:text-white'>
        <SelectGroup>
          {shoeSizes &&
            shoeSizes.map(size => (
              <SelectItem key={size} value={size.toString()}>
                {size}
              </SelectItem>
            ))}
        </SelectGroup>
      </SelectContent>
    </Select>
  );
};

export default SizeSelector;
