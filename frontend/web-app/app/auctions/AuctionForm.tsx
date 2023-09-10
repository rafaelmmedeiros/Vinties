'use client'

import React, {useEffect} from "react";
import {FieldValues, useForm} from "react-hook-form";
import {Button} from "flowbite-react";
import Input from "@/app/components/Input";
import DateInput from "@/app/components/DateInput";

export default function AuctionForm() {
  const {
    control, handleSubmit, setFocus,
    formState: {isSubmitting, isValid, isDirty, errors}
  } = useForm(
    {mode: 'onTouched'}
  )

  useEffect(() => {
    setFocus('brand')
  }, []);

  function onSubmit(data: FieldValues) {
    console.log(data)
  }

  return (
    <form className={'flex flex-col mt-3'} onSubmit={handleSubmit(onSubmit)}>

      <Input label={'Brand'} name={'brand'} control={control} rules={{required: 'Brand is required'}}/>
      <Input label={'Model'} name={'model'} control={control} rules={{required: 'Model is required'}}/>

      <div className={'grid grid-cols-3 gap-3'}>
        <Input label={'Color'} name={'color'} control={control} rules={{required: 'Color is required'}}/>
        <Input label={'Year'} name={'year'} control={control} rules={{required: 'Year is required'}} type={'number'}/>
        <Input label={'Type'} name={'type'} control={control} rules={{required: 'Type is required'}}/>
      </div>
      <Input label={'Description'} name={'description'} control={control}
             rules={{required: 'DescriptionL is required'}}/>
      <Input label={'Image URL'} name={'imageUrl'} control={control} rules={{required: 'Image URL is required'}}/>

      <div className={'grid grid-cols-2 gap-3'}>
        <Input label={'Reserve Price (enter 0 if no reserve)'} name={'reservePrice'} control={control}
               rules={{required: 'Reserve Price is required'}} type={'number'}/>
        <DateInput 
          label={'Auction End Date'} 
          name={'auctionEnd'} control={control}
          dateFormat={'dd MMMM yyyy h:mm a'}
          showTimeSelect={true}
          rules={{required: 'Auction End Date is required'}}
        />
      </div>

      <div className={'flex justify-between'}>
        <Button outline color={'gray'}>Cancel</Button>
        <Button type={'submit'} isProcessing={isSubmitting} outline color={'success'}>Submit</Button>
      </div>
    </form>
  )
}

//   "auctionEnd": "{{dateString}}"