"use client";
import { NavLink, Text } from "@mantine/core";
import Image from "next/image";
import React from "react";
import { Container, Menu } from "./header.styles.ts";
import { usePathname } from "next/navigation";

import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export default function Header() {
  const route = usePathname();
  const notify = () => toast("Wow so easy!");
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
