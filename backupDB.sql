PGDMP      2                     {        	   MachineDB    15.4    15.4                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            	           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            
           1262    16398 	   MachineDB    DATABASE     �   CREATE DATABASE "MachineDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Croatian_Croatia.1250';
    DROP DATABASE "MachineDB";
                postgres    false            �            1259    24576    failure    TABLE     �   CREATE TABLE public.failure (
    id integer NOT NULL,
    name text NOT NULL,
    priority text,
    start_time date,
    end_time date,
    description text,
    status text
);
    DROP TABLE public.failure;
       public         heap    postgres    false            �            1259    24583    failure_machine    TABLE     j   CREATE TABLE public.failure_machine (
    failure_id integer NOT NULL,
    machine_id integer NOT NULL
);
 #   DROP TABLE public.failure_machine;
       public         heap    postgres    false            �            1259    16443    machine    TABLE     Q   CREATE TABLE public.machine (
    id integer NOT NULL,
    name text NOT NULL
);
    DROP TABLE public.machine;
       public         heap    postgres    false                      0    24576    failure 
   TABLE DATA           `   COPY public.failure (id, name, priority, start_time, end_time, description, status) FROM stdin;
    public          postgres    false    215   P                 0    24583    failure_machine 
   TABLE DATA           A   COPY public.failure_machine (failure_id, machine_id) FROM stdin;
    public          postgres    false    216   �                 0    16443    machine 
   TABLE DATA           +   COPY public.machine (id, name) FROM stdin;
    public          postgres    false    214          q           2606    24587 "   failure_machine failure_machine_pk 
   CONSTRAINT     t   ALTER TABLE ONLY public.failure_machine
    ADD CONSTRAINT failure_machine_pk PRIMARY KEY (failure_id, machine_id);
 L   ALTER TABLE ONLY public.failure_machine DROP CONSTRAINT failure_machine_pk;
       public            postgres    false    216    216            o           2606    24582    failure failure_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.failure
    ADD CONSTRAINT failure_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.failure DROP CONSTRAINT failure_pkey;
       public            postgres    false    215            m           2606    16449    machine machine_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.machine
    ADD CONSTRAINT machine_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.machine DROP CONSTRAINT machine_pkey;
       public            postgres    false    214            r           2606    24588 /   failure_machine failure_machine_failure_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.failure_machine
    ADD CONSTRAINT failure_machine_failure_id_fkey FOREIGN KEY (failure_id) REFERENCES public.machine(id);
 Y   ALTER TABLE ONLY public.failure_machine DROP CONSTRAINT failure_machine_failure_id_fkey;
       public          postgres    false    214    216    3181            s           2606    24593 /   failure_machine failure_machine_machine_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.failure_machine
    ADD CONSTRAINT failure_machine_machine_id_fkey FOREIGN KEY (machine_id) REFERENCES public.failure(id);
 Y   ALTER TABLE ONLY public.failure_machine DROP CONSTRAINT failure_machine_machine_id_fkey;
       public          postgres    false    215    3183    216               }   x^3�tK��)-JU0���L��4202�5��5�@f��'e�d�����q�uq���d���׈�9'�85���ۘ�'����kM�M�u�	�RS�^S�l
���׌H�������� *�`j         #   x^3�4�2�4�2�4�2�4�2��9͸b���� 5Z�         =   x^3��I,.�LV�ML���K�2�,.)��K�2�I-.Q����p::�9f���pN� P��     