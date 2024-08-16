"use client";
import React, { useState, Suspense } from "react";
import { Text } from "@mantine/core";

export default function AllRecipes({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <Text>Recipes</Text>
      {children}
    </>
  );
}
