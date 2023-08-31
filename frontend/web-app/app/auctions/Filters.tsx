import React from 'react';
import {Button} from "flowbite-react";
import {useParamsStore} from "@/hooks/useParamsStore";
import {AiOutlineClockCircle, AiOutlineSortAscending} from "react-icons/ai";
import {BsFillStopCircleFill} from "react-icons/bs";

const pageSizeButtons = [4, 8, 16, 32];
const orderByButtons = [
  {label: 'Alphabetical', icon: AiOutlineSortAscending, value: 'brand', },
  {label: 'Ending Date', icon: AiOutlineClockCircle, value: 'endingSoon'},
  {label: 'Added Date', icon: BsFillStopCircleFill, value: 'new'},
];
export default function Filters() {
  const pageSize = useParamsStore(state => state.pageSize)
  const setParams = useParamsStore(state => state.setParams)
  const orderBy = useParamsStore(state => state.orderBy)
  return (
    <div className={'flex justify-between items-center mb-4'}>
      <div>
        <span className={'uppercase text-sm text-gray-500 mr-2'}>Order By</span>
        <Button.Group>
          {orderByButtons.map(({label, icon: Icon, value}) => (
            <Button
              key={value}
              onClick={() => setParams({orderBy: value})}
              color={`${orderBy === value ? 'red' : 'gray'}`}
              className={'focus:ring-0'}
            >
              <Icon className={'mr-2 h-5 w-4'}/>
              {label}
            </Button>
          ))}
        </Button.Group>
      </div>
      <div>
        <span className={'uppercase text-sm text-gray-500 mr-2'}>Page Size</span>
        <Button.Group>
          {pageSizeButtons.map((value, index) => (
            <Button
              key={index}
              color={`${pageSize === value ? 'red' : 'gray'}`}
              onClick={() => setParams({pageSize: value})}
              className={'focus:ring-0'}
            >
              {value}
            </Button>
          ))}
        </Button.Group>
      </div>
    </div>
  );
}