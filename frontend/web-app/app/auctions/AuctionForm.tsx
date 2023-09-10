'use client'

import React from "react";
import {FieldValues, useForm} from "react-hook-form";
import {Button} from "flowbite-react";
import Input from "@/app/components/Input";

export default function AuctionForm() {
  const {control, handleSubmit, setFocus, 
    formState: {isSubmitting, isValid, isDirty, errors}} = useForm()
  
  function onSubmit(data: FieldValues) {
    console.log(data)
  }
  
  return (
    <form className={'flex flex-col mt-3'} onSubmit={handleSubmit(onSubmit)}>
      
      <Input label={'Brand'} name={'brand'} control={control} rules={{required: 'Brand is required'}}/>
      <Input label={'Model'} name={'model'} control={control} rules={{required: 'Model is required'}}/>
      
      <div className={'flex justify-between'}>
        <Button outline color={'gray'}>Cancel</Button>
        <Button type={'submit'} isProcessing={isSubmitting} outline color={'success'}>Submit</Button>
      </div>
    </form>
  )
}