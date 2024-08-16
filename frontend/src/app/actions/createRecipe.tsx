"use server";
import { revalidatePath } from "next/cache";

const nameId = "name";
const stepsId = "steps";
const categoryId = "category";
const linkId = "link";

export async function createRecipe(initial: any, formData: FormData) {
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

  if (response.status === 201) {
    revalidatePath("/all-recipes");
    return true;
  } else {
    return false;
  }
}
