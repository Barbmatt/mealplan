"use client";

import { Button, Text, TextInput, Textarea } from "@mantine/core";
import React from "react";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useRouter } from "next/navigation";
import { AppRouterInstance } from "next/dist/shared/lib/app-router-context.shared-runtime";

const nameId = "name";
const stepsId = "steps";
const categoryId = "category";
const linkId = "link";

async function createRecipe(e: React.FormEvent<HTMLFormElement>) {
  e.preventDefault();
  const formData = new FormData(e.target as HTMLFormElement);

  const rawFormData = {
    name: formData.get(nameId),
    steps: formData.get(stepsId),
    category: formData.get(categoryId),
    link: formData.get(linkId),
  };

  const response = await fetch(
    `${process.env.NEXT_PUBLIC_BACKEND_URL}/Recipes`,
    {
      method: "POST",
      body: JSON.stringify(rawFormData),
      headers: { "Content-Type": "application/json" },
    }
  );
  return response.status === 201;
}

export default function NewRecipeForm() {
  const router = useRouter();

  const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    const result = await createRecipe(e);
    if (result) {
      toast.success("Wow so easy!");
      router.push("/all-recipes");
    } else {
      toast.error("There was an error");
    }
  };

  return (
    <form onSubmit={handleOnSubmit}>
      <Text>Create a New Recipe</Text>
      <TextInput required name={nameId} label="Name" />
      {/* <MultiSelect
        required
        label="Ingredients"
        data={["🥚", "🥛", "🧂", "🍌"]}
      /> */}
      <Textarea name={stepsId} label="Steps" minRows={10} />
      <TextInput
        name={categoryId}
        label="Category"
        description="Specify if the Recipe is a dessert, main meal, drink, dough, etc."
      />
      <TextInput name={linkId} label="Link" />
      <Button type="submit">Save</Button>
    </form>
  );
}
