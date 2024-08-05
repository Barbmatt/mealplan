"use client";
import { NavLink, Text } from "@mantine/core";
import Image from "next/image";
import React from "react";
import { Container, Menu } from "./header.styles.ts";
import { usePathname } from "next/navigation";

export default function Header() {
  const route = usePathname();

  return (
    <Container>
      <Image src="icon.svg" width={30} height={30} alt="icon" />
      <Text style={{ paddingRight: "2rem" }}>Mealplan</Text>
      <Menu>
        <NavLink
          href="/calendar"
          label="Calendar"
          active={route === "/calendar"}
        ></NavLink>
        <NavLink
          href="/all-recipes"
          label="All Recipes"
          active={route === "/all-recipes"}
        ></NavLink>
        <NavLink
          href="/new-recipe"
          label="New Recipe"
          active={route === "/new-recipe"}
        ></NavLink>
      </Menu>
    </Container>
  );
}
