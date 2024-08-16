"use server";
import React, { useState, Suspense } from "react";
import { Text } from "@mantine/core";
import { revalidatePath } from "next/cache";

type Recipe = {
  id: number;
  name: string;
  category?: string;
  description?: string;
  link?: string;
};

export default async function currentRecipes(): Promise<React.JSX.Element> {
  const response: Recipe[] = await fetch(
    `${process.env.NEXT_PUBLIC_BACKEND_URL}/Recipes`,
    {
      method: "GET",
      headers: { "Content-Type": "application/json" },
    }
  ).then((res) => res.json());

  return (
    <>
      {response
        .sort((a, b) => (a.id < b.id ? 1 : -1))
        .map((e) => (
          <li key={e.id}>{e.name}</li>
        ))}
    </>
  );
}
