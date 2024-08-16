"use client";
import { Button, Text, TextInput, Textarea } from "@mantine/core";
import React, { useActionState, useEffect } from "react";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { redirect, useRouter } from "next/navigation";
import { AppRouterInstance } from "next/dist/shared/lib/app-router-context.shared-runtime";
import { revalidatePath } from "next/cache";
import { createRecipe } from "../actions/createRecipe";
import { useFormState } from "react-dom";

const nameId = "name";
const stepsId = "steps";
const categoryId = "category";
const linkId = "link";

export default function NewRecipeForm() {
  const router = useRouter();
  const [state, action] = useFormState(createRecipe, undefined);

  useEffect(() => {
    if (state === true) {
      toast.success("Wow so easy!");
      router.push("all-recipes");
    } else if (state === false) {
      toast.error("error");
    }
  }, [router, state]);

  return (
    <form action={action}>
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
