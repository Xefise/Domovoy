import {Target, Transition, Variants} from "framer-motion";

export const translition: Transition = {
    type: "spring",
    bounce: 0
}

export const initialUp: Target = {
    y: -300,
    opacity: 0,
}

export const enterUp: Target = {
    y: 0,
    opacity: 1
}

export const exitUp: Target = {
    y: -100,
    opacity: 0
}

export const upVariants: Variants = {
    "init": initialUp,
    "show": {
        ...enterUp, transition: {
            duration: 0.7,
            ...translition
        }
    },
    "hide": {
        ...exitUp, transition: {
            duration: 0.3,
            ...translition
        }
    }
}

export const initialHorizontal: Target = {
    x: -300,
    opacity: 0,
}

export const enterHorizontal: Target = {
    x: 0,
    opacity: 1
}

export const exitHorizontal: Target = {
    x: 300,
    opacity: 0
}

export const horizontalVariants: Variants = {
    "init": initialHorizontal,
    "show": {
        ...enterHorizontal, transition: {
            duration: 0.7,
            ...translition
        }
    },
    "hide": {
        ...exitHorizontal, transition: {
            duration: 0.3,
            ...translition
        }
    }
}

export const initialCard: Target = {
    y: 100,
    opacity: 0,
}

export const enterCard: Target = {
    y: 0,
    opacity: 1
}

export const exitCard: Target = {
    y: 100,
    opacity: 0
}

export const cardVariants: Variants = {
    "init": initialCard,
    "show": {
        ...enterCard, transition: {
            duration: 0.7,
            ...translition
        }
    },
    "hide": {
        ...exitCard, transition: {
            duration: 0.3,
            ...translition
        }
    }
}