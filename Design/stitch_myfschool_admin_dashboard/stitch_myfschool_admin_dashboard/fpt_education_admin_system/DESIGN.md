---
name: FPT Education Admin System
colors:
  surface: '#f9f9f9'
  surface-dim: '#dadada'
  surface-bright: '#f9f9f9'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#f3f3f3'
  surface-container: '#eeeeee'
  surface-container-high: '#e8e8e8'
  surface-container-highest: '#e2e2e2'
  on-surface: '#1a1c1c'
  on-surface-variant: '#584238'
  inverse-surface: '#2f3131'
  inverse-on-surface: '#f1f1f1'
  outline: '#8c7166'
  outline-variant: '#e0c0b2'
  surface-tint: '#a04100'
  primary: '#a04100'
  on-primary: '#ffffff'
  primary-container: '#f27024'
  on-primary-container: '#541e00'
  inverse-primary: '#ffb693'
  secondary: '#5f5e5e'
  on-secondary: '#ffffff'
  secondary-container: '#e2dfde'
  on-secondary-container: '#636262'
  tertiary: '#1a619d'
  on-tertiary: '#ffffff'
  tertiary-container: '#5f9ad9'
  on-tertiary-container: '#003055'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#ffdbcc'
  primary-fixed-dim: '#ffb693'
  on-primary-fixed: '#351000'
  on-primary-fixed-variant: '#7a3000'
  secondary-fixed: '#e5e2e1'
  secondary-fixed-dim: '#c8c6c5'
  on-secondary-fixed: '#1c1b1b'
  on-secondary-fixed-variant: '#474746'
  tertiary-fixed: '#d1e4ff'
  tertiary-fixed-dim: '#9ecaff'
  on-tertiary-fixed: '#001d36'
  on-tertiary-fixed-variant: '#00497c'
  background: '#f9f9f9'
  on-background: '#1a1c1c'
  surface-variant: '#e2e2e2'
typography:
  display-lg:
    fontFamily: Montserrat
    fontSize: 32px
    fontWeight: '700'
    lineHeight: 40px
    letterSpacing: -0.02em
  display-lg-mobile:
    fontFamily: Montserrat
    fontSize: 24px
    fontWeight: '700'
    lineHeight: 32px
  headline-md:
    fontFamily: Montserrat
    fontSize: 20px
    fontWeight: '600'
    lineHeight: 28px
  body-lg:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '400'
    lineHeight: 24px
  body-md:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '400'
    lineHeight: 20px
  label-md:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: '600'
    lineHeight: 16px
    letterSpacing: 0.05em
  button:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '600'
    lineHeight: 20px
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  base: 4px
  xs: 4px
  sm: 8px
  md: 16px
  lg: 24px
  xl: 32px
  2xl: 48px
  container-margin: 24px
  gutter: 16px
---

## Brand & Style
The brand personality is **energetic, professional, and structured**. Designed specifically for high school administrators, the UI balances the vibrant spirit of a student-centric environment with the rigorous utility required for academic management.

The design style follows a **Modern Corporate** approach with a focus on high-readiness and organizational clarity. It utilizes a clean, card-based architecture to modularize complex data, ensuring that the interface feels approachable rather than overwhelming. The aesthetic is defined by ample white space, purposeful pops of brand orange, and a rigid underlying grid that reflects the stability of an educational institution.

## Colors
This design system utilizes a high-contrast palette to drive focus and hierarchy.
- **Primary Orange (#F27024):** Used for primary actions, active navigation states, and brand-critical elements. It signifies energy and momentum.
- **Secondary Dark (#1A1A1A):** Employed for high-level typography and the sidebar background to provide a solid visual anchor.
- **Neutral Gray (#F5F5F5):** The foundation for all background surfaces, helping to reduce eye strain during long administrative sessions.
- **Surface White (#FFFFFF):** Reserved for cards and input fields to create a clear "layer" above the background.
- **Accent Blue (#005691):** Used sparingly for secondary informative links or specific data visualizations to contrast with the primary orange.

## Typography
The typography strategy pairs **Montserrat** for headlines to convey a bold, modern authority, with **Inter** for all body and UI elements to ensure maximum legibility in data-dense environments.

- **Headlines:** Use Montserrat Bold/SemiBold for page titles and section headers.
- **Body Text:** Use Inter Regular for all descriptions and data entries.
- **Data Labels:** Use Inter SemiBold in all-caps at 12px for table headers and form labels to create distinct visual separation from the data itself.
- **Hierarchy:** Ensure a clear vertical rhythm by strictly adhering to the defined line heights.

## Layout & Spacing
The system utilizes a **12-column fluid grid** for the main content area, with a fixed-width sidebar (256px) on desktop.

- **Consistency:** All spacing is based on a **4px base unit**. Use `16px (md)` for standard padding inside cards and `24px (lg)` for gaps between major layout sections.
- **Responsive Behavior:** 
  - **Desktop (1440px+):** 12 columns, 24px margins.
  - **Tablet (768px - 1024px):** 6 columns, 16px margins, sidebar collapses to icons.
  - **Mobile (<768px):** 4 columns, 16px margins, sidebar becomes a hidden drawer.
- **Alignment:** All form elements should align to the left edge of the grid columns to maintain a clean vertical scan line for users.

## Elevation & Depth
Depth is created through **Tonal Layering** and subtle ambient shadows to separate the workspace from the canvas.

- **Level 0 (Background):** Neutral Gray (#F5F5F5) - The bottom-most layer.
- **Level 1 (Cards/Sidebar):** White (#FFFFFF) - Uses a very soft, diffused shadow (0px 2px 4px rgba(0,0,0,0.05)) and a 1px border (#E5E5E5) to define boundaries.
- **Level 2 (Dropdowns/Modals):** White (#FFFFFF) - Uses a more pronounced shadow (0px 8px 16px rgba(0,0,0,0.1)) to indicate interactive overlays.
- **Interactive States:** Buttons and clickable cards do not lift on hover; instead, they utilize a subtle background color shift (5% darker) to maintain a flat, professional aesthetic.

## Shapes
The shape language is **friendly yet disciplined**. 
- **Standard Radius:** A 0.5rem (8px) corner radius is applied to all primary UI components including buttons, input fields, and cards.
- **Small Components:** Chips and badges use a 4px radius for a sharper, more precise look.
- **Icons:** Use linear, 2px stroke icons with slightly rounded terminals to match the typography's soft-geometric feel.

## Components
- **Buttons:** Primary buttons are solid Orange (#F27024) with white text. Secondary buttons are outlined in Light Gray with Dark Gray text. Height is fixed at 40px for standard actions.
- **Cards:** Used for all dashboard widgets and content grouping. Cards must include a 16px padding and a subtle 1px border to ensure they don't bleed into the background on high-brightness monitors.
- **Tables:** Essential for school admin. Use a "Zebra-stripe" pattern with very light gray (#FAFAFA) for alternate rows. Table headers should be sticky with a 2px Orange bottom border.
- **Input Fields:** 8px border-radius, 1px Gray border. On focus, the border transitions to Orange with a 2px outer "glow" of 10% opacity Orange.
- **Status Chips:** Use a palette of Soft Green, Soft Red, and Soft Blue with dark text for status indicators (e.g., "Enrolled", "Suspended", "Graduated").
- **Sidebar:** Dark Navy background with white icons. Active states are indicated by a vertical 4px Orange line on the left edge of the menu item.