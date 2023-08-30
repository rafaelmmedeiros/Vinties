import React from 'react';
import ButtonGroup from "flowbite-react/lib/esm/components/Button/ButtonGroup";
import {Button} from "flowbite-react";

type Props = {
  pageSize: number;
  setPageSize: (size: number) => void;
}

const pageSizeButtons = [4, 8, 16, 32];

export default function Filters({ pageSize, setPageSize }: Props) {
  return (
    <div className={'flex justify-between items-center mb-4'}>
      <div>
        <span className={'uppercase text-sm text-gray-500 mr-2'}>Page Size</span>
        <ButtonGroup>
          {pageSizeButtons.map((value, index) => (
            <Button
              key={index}
              color={`${pageSize === value ? 'red' : 'gray'}`}
              onClick={() => setPageSize(value)}
              className={'focus:ring-0'}
            >
              {value}
            </Button>
          ))}
        </ButtonGroup>
      </div>
    </div>
  );
}